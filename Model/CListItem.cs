using System;

namespace Model
{
    public class CListItem
    {
        private string text;
        private string value;
        public string Text
        {

            get
            {
                return this.text;
            }

            set
            {
                this.text = value;
            }
        }
        public string Value
        {

            get
            {
                return this.value;
            }

            set
            {
                this.value = value;
            }
        }

        public CListItem(string text, string value)
        {
            this.text = text;
            this.value = value;
        }

        public CListItem(string text)
        {
            this.text = text;
            this.value = text;
        }

        public override string ToString()
        {
            return this.Text.ToString();
        }
    }
}

