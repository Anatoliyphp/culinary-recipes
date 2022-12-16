using recipe_domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application
{
	public class StepValidator: IValidator<Step>
	{
		public override IReadOnlyList<Exception> GetExceptions(Step step)
		{
			List<Exception> exceptions = new List<Exception>();

			if (step.Name.Length > 20 || step.Name.Length == 0)
			{
				exceptions.Add(new ArgumentOutOfRangeException("Step name has invalid length"));
			}

			if (step.Desc.Length > 200 || step.Desc.Length == 0)
			{
				exceptions.Add(new ArgumentOutOfRangeException("Step description has invalid length"));
			}

			return exceptions;
		}

	}
}
