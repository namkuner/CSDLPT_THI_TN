using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThiTN.Model
{
    internal class ActionModel
    {
        public enum ActionType
        {
            Add,
            Edit,
            Delete
        }

        public ActionType Type { get; set; }
        public QuestionState State { get; set; }

        public ActionModel(ActionType type, QuestionState state)
        {
            Type = type;
            State = state;
        }
    }
}
