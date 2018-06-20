using System;
namespace LojaDeMoveis
{
	public class ModelException : Exception
    {
		public ModelException(string msg): base(msg)
        {
        }
    }
}
