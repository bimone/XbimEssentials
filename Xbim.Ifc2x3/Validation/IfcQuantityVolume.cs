using System;
using log4net;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using Xbim.Common.Enumerations;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc2x3.Interfaces;
using Xbim.Ifc2x3.Kernel;
using Xbim.Ifc2x3.ProfileResource;
using Xbim.Ifc2x3.ProfilePropertyResource;
using static Xbim.Ifc2x3.Functions;
// ReSharper disable once CheckNamespace
// ReSharper disable InconsistentNaming
namespace Xbim.Ifc2x3.QuantityResource
{
	public partial class IfcQuantityVolume : IExpressValidatable
	{
		private static readonly ILog Log = LogManager.GetLogger("Xbim.Ifc2x3.QuantityResource.IfcQuantityVolume");

		/// <summary>
		/// Tests the express where-clause specified in param 'clause'
		/// </summary>
		/// <param name="clause">The express clause to test</param>
		/// <returns>true if the clause is satisfied.</returns>
		public bool ValidateClause(Where.IfcQuantityVolume clause) {
			var retVal = false;
			if (clause == Where.IfcQuantityVolume.WR21) {
				try {
					retVal = !(EXISTS(this/* as IfcPhysicalSimpleQuantity*/.Unit)) || (this/* as IfcPhysicalSimpleQuantity*/.Unit.UnitType == IfcUnitEnum.VOLUMEUNIT);
				} catch (Exception ex) {
					Log.Error($"Exception thrown evaluating where-clause 'IfcQuantityVolume.WR21' for #{EntityLabel}.", ex);
				}
				return retVal;
			}
			if (clause == Where.IfcQuantityVolume.WR22) {
				try {
					retVal = VolumeValue >= 0;
				} catch (Exception ex) {
					Log.Error($"Exception thrown evaluating where-clause 'IfcQuantityVolume.WR22' for #{EntityLabel}.", ex);
				}
				return retVal;
			}
			throw new ArgumentException($"Invalid clause specifier: '{clause}'", nameof(clause));
		}

		public IEnumerable<ValidationResult> Validate()
		{
			if (!ValidateClause(Where.IfcQuantityVolume.WR21))
				yield return new ValidationResult() { Item = this, IssueSource = "IfcQuantityVolume.WR21", IssueType = ValidationFlags.EntityWhereClauses };
			if (!ValidateClause(Where.IfcQuantityVolume.WR22))
				yield return new ValidationResult() { Item = this, IssueSource = "IfcQuantityVolume.WR22", IssueType = ValidationFlags.EntityWhereClauses };
		}
	}
}
// ReSharper disable once CheckNamespace
// ReSharper disable InconsistentNaming
namespace Xbim.Ifc2x3.Where
{
	public class IfcQuantityVolume
	{
		public static readonly IfcQuantityVolume WR21 = new IfcQuantityVolume();
		public static readonly IfcQuantityVolume WR22 = new IfcQuantityVolume();
		protected IfcQuantityVolume() {}
	}
}