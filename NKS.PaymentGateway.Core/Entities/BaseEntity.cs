using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NKS.PaymentGateway.Core.Interfaces;

namespace NKS.PaymentGateway.Core.Entities
{
    public abstract class BaseEntity : IEquatable<BaseEntity>, IObjectState
    {
        private readonly List<Rule> _brokenRules = new List<Rule>();

        public BaseEntity(Guid id)
        {
            Id = id;
        }
        public BaseEntity()
        {

        }
        public Guid Id { get; set; }

        protected virtual object Actual => this;
        public ObjectState State { get; set; }
        public bool IsActive => true;

        public void SetModified()
        {
            if (Status == ObjectState.Unchanged)
                Status = ObjectState.Modified;
        }

        public void SetDeleted()
        {
            Status = ObjectState.Deleted;
        }
        protected void AddBrokenRule(Rule businessRule)
        {
            _brokenRules.Add(businessRule);
        }

        public IEnumerable<Rule> GetBrokenRules()
        {
            _brokenRules.Clear();
            Validate();
            return _brokenRules;
        }

        protected abstract void Validate();

        public override bool Equals(object obj)
        {
            return this.Equals(obj as BaseEntity);
        }

        public static bool operator ==(BaseEntity a, BaseEntity b)
        {
            if (a is null && b is null)
                return true;

            if (a is null || b is null)
                return false;

            return a.Equals(b);
        }
        public static bool operator !=(BaseEntity a, BaseEntity b)
        {
            return !(a == b);
        }

        public bool Equals(BaseEntity other)
        {
            if (other is null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            if (Actual.GetType() != other.Actual.GetType())
                return false;

            if (Id == Guid.Empty || other.Id == Guid.Empty)
                return false;

            return Id == other.Id;
        }
    }
}
