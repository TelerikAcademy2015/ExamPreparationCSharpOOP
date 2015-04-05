namespace DocumentSystem.Models
{
    using System;
    using System.Collections.Generic;
    using DocumentSystem.Interfaces;

    public abstract class BinaryDocument : Document, IDocument
    {
        public BinaryDocument(string name, string content = null, long size = 0)
            : base(name, content)
        {
            this.Size = size;
        }

        public long Size { get; private set; }

        public override void LoadProperty(string key, string value)
        {
            key = key.ToLower();
            if (key == "size")
            {
                this.Size = long.Parse(value);
            }
            else
            {
                base.LoadProperty(key, value);
            }
        }

        public override void SaveAllProperties(System.Collections.Generic.IList<System.Collections.Generic.KeyValuePair<string, object>> output)
        {
            if (this.Size != 0)
            {
                output.Add(new KeyValuePair<string, object>("size", this.Size));
            }
            base.SaveAllProperties(output);
        }
    }
}
