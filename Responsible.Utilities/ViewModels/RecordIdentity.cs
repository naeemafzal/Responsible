namespace Responsible.Utilities.ViewModels
{
    /// <summary>
    /// An instance representing a simple record
    /// </summary>
    public class RecordIdentity
    {
        /// <summary>
        /// Identity of the record
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Display name of the record
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Creates an empty instance of <see cref="RecordIdentity"/>
        /// </summary>
        public RecordIdentity() { }

        /// <summary>
        /// Creates an instance of <see cref="RecordIdentity"/> with Id and Name
        /// </summary>
        public RecordIdentity(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }

    /// <summary>
    /// An instance representing a simple record
    /// </summary>
    public class RecordIdentity<TKey>
    {
        /// <summary>
        /// Identity of the record
        /// </summary>
        public TKey Id { get; set; }

        /// <summary>
        /// Display name of the record
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Creates an empty instance of <see cref="RecordIdentity{TKey}"/>
        /// </summary>
        public RecordIdentity() { }

        /// <summary>
        /// Creates an instance of <see cref="RecordIdentity{TKey}"/> with Id and Name
        /// </summary>
        public RecordIdentity(TKey id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
