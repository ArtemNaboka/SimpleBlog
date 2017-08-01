namespace Blog.Infrastructure
{
    public struct LabelValuePair<TValue>
    {
        public string Label { get; set; }
        public TValue Value { get; set; }

        public LabelValuePair(string label)
        {
            Label = label;
            Value = default(TValue);
        }

        public LabelValuePair(string label, TValue value)
        {
            Label = label;
            Value = value;
        }
    }
}