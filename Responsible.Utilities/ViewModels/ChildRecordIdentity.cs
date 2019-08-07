namespace Responsible.Utilities.ViewModels
{
    /// <summary>
    /// An instance representing a simple child record
    /// </summary>
    public class ChildRecordIdentity : RecordIdentity
    {
        /// <summary>
        /// Parent Identity of the record
        /// </summary>
        public int ParentId { get; set; }

        /// <summary>
        /// Empty constructor
        /// </summary>
        public ChildRecordIdentity() { }

        /// <summary>
        /// Constructor with values
        /// </summary>
        /// <param name="id">The identity of the record</param>
        /// <param name="name">Display name of the record</param>
        /// <param name="parentId">The Identity of the parent record</param>
        public ChildRecordIdentity(int id, string name, int parentId)
        {
            Id = id;
            Name = name;
            ParentId = parentId;
        }
    }

    /// <summary>
    /// An instance representing a simple child record
    /// </summary>
    public class ChildRecordIdentity<TId, TParentId> : RecordIdentity<TId>
    {
        /// <summary>
        /// Parent Identity of the record
        /// </summary>
        public TParentId ParentId { get; set; }

        /// <summary>
        /// Empty constructor
        /// </summary>
        public ChildRecordIdentity() { }

        /// <summary>
        /// Constructor with values
        /// </summary>
        /// <param name="id">The identity of the record</param>
        /// <param name="name">Display name of the record</param>
        /// <param name="parentId">The Identity of the parent record</param>
        public ChildRecordIdentity(TId id, string name, TParentId parentId)
        {
            Id = id;
            Name = name;
            ParentId = parentId;
        }
    }
}