namespace DocumentSystem.Models
{
    using System;
    using System.Collections.Generic;
    using DocumentSystem.Interfaces;

    public class ExcelDocument : OfficeDocument, IDocument, IEncryptable
    {
        public ExcelDocument(string name, string content = null, long size = 0, string version = null, long numberOfColumns = 0, long numberOfRows = 0)
            : base(name, content, size, version)
        {
            this.NumberOfColumns = numberOfColumns;
            this.NumberOfRows = numberOfRows;
        }

        public long NumberOfColumns { get; private set; }

        public long NumberOfRows { get; private set; }

        public override void LoadProperty(string key, string value)
        {
            key = key.ToLower();
            if (key == "rows")
            {
                this.NumberOfRows = long.Parse(value);
            }
            else if (key == "cols")
            {
                this.NumberOfColumns = long.Parse(value);
            }
            else
            {
                base.LoadProperty(key, value);
            }
        }

        public override void SaveAllProperties(System.Collections.Generic.IList<System.Collections.Generic.KeyValuePair<string, object>> output)
        {
            if (this.NumberOfRows != 0)
            {
                output.Add(new KeyValuePair<string, object>("rows", this.NumberOfRows));
            }

            if (this.NumberOfColumns != 0)
            {
                output.Add(new KeyValuePair<string, object>("cols", this.NumberOfColumns));
            }
            base.SaveAllProperties(output);
        }
    }
}
