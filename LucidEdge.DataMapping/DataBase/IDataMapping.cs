using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LucidEdge.DataMapping
{
	public interface IDataMapping
	{
		IDictionary<string,DataPoint> Map { get; set; }
	}
}
