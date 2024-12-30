using BOOSE;

namespace ASE_Assignment;

/// <summary>
/// Array class for creating array variables within the BOOSE language.
/// </summary>
public class AppArray : Evaluation
{
    private int rows;
    private int row;
    private int columns = 1; //default value if no length is specified
    private int column;
    private string rowString = "0";
    private string columnString = "0";
    private int Rows => this.rows;
    private int Columns => this.columns;
    
    protected string variableType = "";
    private int[,] intArray;
    private double[,] realArray;

    protected string pokeValue;
    protected string peekValue;

    protected int valueInt;
    protected double valueReal;

    /// <summary>
    /// Checks if the array has been called with the correct number of parameters.
    /// </summary>
    /// <param name="parameterList">Variable containing the parameters passed.</param>
    /// <exception cref="CommandException">Thrown if 3 > number of parameters > 4</exception>
    public override void CheckParameters(string[] parameterList)
    {
        this.Parameters = this.ParameterList.Trim().Split(" ");
        if (this.Parameters.Length != 3 && this.Parameters.Length != 4)
            throw new CommandException("Invalid declaration of array");
    }

    /// <summary>
    /// Compile method calls <see cref="Evaluation.Compile"/> then parses parameters to determine if the program is runnable. If any errors are caught
    /// when compiling, a <see cref="CommandException"/> is thrown.
    /// </summary>
    /// <exception cref="CommandException">CommandException is thrown if any of the parameters cannot be parsed or the array type passed by the
    /// user is not recognised.
    /// </exception>
    public override void Compile()
    {
        base.Compile();
        bool error = false;
        error = !int.TryParse(this.parameters[2], out this.rows); //On fail to parse set error flag to true
        this.varName = this.parameters[1]; //Variable name for the array
        if (this.parameters.Length == 4) //If 4 parameters given set columns value else will remain default
        {
            error = !int.TryParse(this.parameters[3], out this.columns); //On fail to parse to int set error to true
        }
        if (this.parameters[0] != "int" && this.parameters[0] != "real") //If type is not int or real set error to true
        {
            error = true;
        }
        if (error)
        {
            throw new CommandException("Invalid declaration of array");
        }
        this.variableType = this.parameters[0];
        this.Program.AddVariable(this);
    }

    /// <summary>
    /// This method calls <see cref="Evaluation.Execute"/> then creates an array of the type specified by given parameter. If the type is not recognised
    /// a <see cref="CommandException"/> is thrown.
    /// </summary>
    /// <exception cref="CommandException">CommandException is thrown if the given array type is unknown.</exception>
    public override void Execute()
    {
        base.Execute();
        switch (this.variableType) //Switch case using variableType to create an array of type int or real.
        {
            case "int":
                this.intArray = new int[this.rows, this.columns];
                break;
            case "real":
                this.realArray = new double[this.rows, this.columns];
                break;
            default:
                throw new CommandException("Unknown array type, needs int or real");
        }
    }

    /// <summary>
    /// Processes array parameters during compilation. Determines the poke or peek values and validates provided parameters.
    /// </summary>
    /// <param name="isPoke">Determines if the operation is poke or peek.</param>
    /// <exception cref="CommandException">Throw when invalid parameters are passed</exception>
    public void ProcessArrayParametersCompile(bool isPoke)
    {
        int peekIndex;
        int pokeIndex;

        //if the following command is passed "poke nums 5 = 99", the parameters will be broken up as such ["nums 5", "99"]
        //whereas if the command was "peek x = nums 5" it would be broken up as ["x", nums 5"]
        //if is peek() then value will be at index[1]
        if (!isPoke) 
        {
            peekIndex = 1;
            pokeIndex = 0;
        }
        //if is poke() position will be at index[1]
        else 
        {
            peekIndex = 0;
            pokeIndex = 1;
        }

        String[] assignmentParts = parameterList.Split("=");
        if (assignmentParts.Length > 1) //Set poke and peek value
        {
            this.pokeValue = assignmentParts[pokeIndex].Trim();
            this.peekValue = this.pokeValue;
        }
        String[] arrayParams = assignmentParts[peekIndex].Trim().Split(" ");
        if (assignmentParts.Length < 2 || arrayParams.Length < 1)
        {
            throw new CommandException("Invalid parameters passed with array");
        }
        this.varName = arrayParams[0].Trim(); //Set variable name of the array
        this.rowString = arrayParams[1];
        if (arrayParams.Length != 3)
            return;
        this.columnString = arrayParams[2];
    }

    /// <summary>
    /// Processes the array parameters during execution. Validates parsed values and then performs the poke or peek operation.
    /// </summary>
    /// <param name="isPoke">Determines if the operation is poke or peek.</param>
    /// <exception cref="CommandException">Thrown if column or row values are invalid, or the variable type is not real or int.</exception>
    public void ProcessArrayParametersExecute(bool isPoke)
    {
        var row = this.rowString;
        var column = this.columnString;
        var arrayPokeValue = this.pokeValue;

        if (this.program.IsExpression(this.rowString))
            row = this.Program.EvaluateExpression(this.rowString).Trim().ToLower();
        if (this.program.IsExpression(this.columnString))
            column = this.Program.EvaluateExpression(this.columnString).Trim().ToLower();
        if (this.program.IsExpression(this.pokeValue))
            arrayPokeValue = this.Program.EvaluateExpression(this.pokeValue).Trim().ToLower();
       
        bool rowErr = !int.TryParse(row, out this.row);
        bool colErr = !int.TryParse(column, out this.column);
        if (rowErr || colErr)
        {
            throw new CommandException("Row or column are invalid");
        }

        AppArray variable = (AppArray)this.program.GetVariable(this.varName);
        if (variable.variableType.Equals("int"))
        {
            this.variableType = "int";
            if (!int.TryParse(arrayPokeValue, out this.valueInt))
            {
                throw new CommandException("Poke value should be of type int");
            }
            //if is poke operation check array bounds then set value of intArray
            if (isPoke)
            {
                variable.CheckBounds(this.row, this.column);
                variable.intArray[this.row, this.column] = this.valueInt;
            } 
            //else operation is peek, so check array bounds then retrieve the value
            else
            {
                variable.CheckBounds(this.row, this.column);
                this.valueInt = variable.intArray[this.row, this.column];
            }
        } 
        else if (variable.variableType.Equals("real"))
        {
            this.variableType = "real";
            if (!double.TryParse(arrayPokeValue, out this.valueReal))
            {
                throw new CommandException("Poke value should be of type real");
            }
            //if is poke operation check array bounds then set value of realArray
            if (isPoke)
            {
                variable.CheckBounds(this.row, this.column);
                variable.realArray[this.row, this.column] = this.valueReal;
            } 
            //else operation is peek, so check array bounds then retrieve the value
            else
            {
                variable.CheckBounds(this.row, this.column);
                this.valueReal = variable.realArray[this.row, this.column];
            }
        } else throw new CommandException("Cannot create array that is not of type int or real");
    }

    private void CheckBounds(int row, int col)
    {
        if (row >= this.rows || col >= this.columns)
            throw new CommandException("Array index out of bounds");
    }
}