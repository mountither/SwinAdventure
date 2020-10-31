using System;
using System.Collections.Generic;
using System.Text;

namespace SwinAdven
{
    public class IdentifiableObject
    {
        private List<string> _identifiers;

        public IdentifiableObject(List<string> idents)
        {
            _identifiers = idents;
        }

        public bool AreYou(string id)
        {
            //for loop that iterates the identifier array and finds a match id. 
            for (int i = 0; i < _identifiers.Count; i++)
            {
                if (id.ToLower() == _identifiers[i].ToLower())
                    return true;
            }
            return false;
        }



        public string FirstId
        {
            get
            {
                return _identifiers[0];
            }

        }

        public void AddIdentifier(string id)
        {
            string lowCaseId = id.ToLower();
            _identifiers.Add(lowCaseId);
                
        }
    }
}

