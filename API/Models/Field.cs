namespace ECODB1st2024Jul17.Models
{
    public class Field
    {
        public bool? autoClose { get; set; }
        public bool? clearButton { get; set; }
        public int column { get; set; }
        public List<object>? dataSource { get; set; }
        public string dataType { get; set; }
        public string? fieldName { get; set; }
        public bool? filterable { get; set; }
        public string? format { get; set; }
        public string? icon { get; set; }
        public bool? isMultiSelectCheckbox { get; set; }
        public bool? isSpinnersRequired { get; set; }
        public bool? isValuePrimitive { get; set; }
        public string? label { get; set; }
        public int? length { get; set; }
        public double? max { get; set; }
        public DateTime? maxDate { get; set; }
        public int? maxlength { get; set; }
        public double? min { get; set; }
        public DateTime? minDate { get; set; }
        public int? minlength { get; set; }
        public string? operatorForSearch { get; set; } // Alternatively, use an enum if only specific values are allowed
        public bool? readOnly { get; set; }
        public bool? required { get; set; }
        public string? resizable { get; set; }
        public int? scale { get; set; }
        public bool? showDefaultValue { get; set; }
        public bool? showHorizontal { get; set; }
        public bool? showIndividual { get; set; }
        public bool? showNumericFormat { get; set; }
        public bool? suggest { get; set; }
        public string? textField { get; set; }
        public string? type { get; set; }
        public object? value { get; set; }
        public string? valueField { get; set; }

        // for section, tab
        public List<Field>? fields { get; set; }
        public bool? showTitle { get; set; }

        public Field()
        {
            column = 12;
            dataType = "string";
        }

        public Field(string dataType, string fieldName)
        {
            column = 12;
            dataType = dataType;
            fieldName = fieldName;
        }
    }
}
