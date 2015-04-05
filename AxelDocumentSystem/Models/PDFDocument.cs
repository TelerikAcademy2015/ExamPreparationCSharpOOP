namespace DocumentSystem.Models
{
    using System;
    using System.Collections.Generic;
    using DocumentSystem.Interfaces;

    public class PDFDocument : EncriptableDocument, IDocument, IEncryptable
    {
        public PDFDocument(string name, string content = null, int size = 0, long numberOfPages = 0)
            : base(name, content, size)
        {
            this.NumberOfPages = numberOfPages;
        }

        public long NumberOfPages { get; private set; }

        public override void LoadProperty(string key, string value)
        {
            key = key.ToLower();
            if (key == "pages")
            {
                this.NumberOfPages = long.Parse(value);
            }
            else
            {
                base.LoadProperty(key, value);
            }
        }

        public override void SaveAllProperties(System.Collections.Generic.IList<System.Collections.Generic.KeyValuePair<string, object>> output)
        {
            if (this.NumberOfPages != 0)
            {
                output.Add(new KeyValuePair<string, object>("pages", this.NumberOfPages));
            }
            base.SaveAllProperties(output);
        }
    }
}
