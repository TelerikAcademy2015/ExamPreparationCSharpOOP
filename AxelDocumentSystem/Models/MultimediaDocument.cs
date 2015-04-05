namespace DocumentSystem.Models
{
    using System;
    using System.Collections.Generic;
    using DocumentSystem.Interfaces;

    public abstract class MultimediaDocument: BinaryDocument, IDocument
    {
        public MultimediaDocument(string name, string content = null, long size = 0, long length = 0)
            : base(name, content, size)
        {
            this.Length = length;
        }

        public long Length { get; private set; }

        public override void LoadProperty(string key, string value)
        {
            if (key.ToLower() == "length")
            { this.Length = long.Parse(value); }
            else
            { base.LoadProperty(key, value); }
        }

        public override void SaveAllProperties(System.Collections.Generic.IList<System.Collections.Generic.KeyValuePair<string, object>> output)
        {
            if (this.Length != 0)
            {
                output.Add(new KeyValuePair<string, object>("length", this.Length));
            }
            base.SaveAllProperties(output);
        }
    }
}
