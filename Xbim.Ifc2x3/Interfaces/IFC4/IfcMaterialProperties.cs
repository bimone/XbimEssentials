// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool Xbim.CodeGeneration 
//  
//     Changes to this file may cause incorrect behaviour and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------

using System;
using Xbim.Ifc4.Interfaces;
using System.Collections.Generic;
using System.Linq;
using Xbim.Ifc2x3.Interfaces.Conversions;
using Xbim.Ifc2x3.MeasureResource;

// ReSharper disable once CheckNamespace
namespace Xbim.Ifc2x3.MaterialPropertyResource
{
	public partial class @IfcMaterialProperties : IIfcMaterialProperties
	{
		IIfcMaterialDefinition IIfcMaterialProperties.Material 
		{ 
			get
			{
				return Material as IIfcMaterialDefinition;
			} 
		}
		Ifc4.MeasureResource.IfcIdentifier? IIfcExtendedProperties.Name 
		{ 
			get
			{
				//## Handle return of Name for which no match was found
			    return null;
			    //##
			} 
		}
		Ifc4.MeasureResource.IfcText? IIfcExtendedProperties.Description 
		{ 
			get
			{
				//## Handle return of Description for which no match was found
                return null;
				//##
			} 
		}


		IEnumerable<IIfcProperty> IIfcExtendedProperties.Properties 
		{ 
			get
			{
				//## Handle return of Properties for which no match was found
                // Properties which are represented as objects in IFC2x3 has to be represented as transient property objects
			    var properties = GetType().GetProperties().Where(p => typeof (IfcValue).IsAssignableFrom(p.PropertyType));
			    foreach (var property in properties)
			    {
			        var name = property.Name;
			        var value = property.GetValue(this, null);
			        if (value == null) continue;

			        var sourceType = property.PropertyType.IsGenericType
			            ? property.PropertyType.GetGenericArguments()[0]
			            : property.PropertyType;

			        var targetType =
			            typeof (Ifc4.MeasureResource.IfcValue).Assembly.GetTypes()
			                .FirstOrDefault(
			                    t => t.IsValueType &&
			                        string.Compare(t.Name, sourceType.Name,
			                            StringComparison.InvariantCultureIgnoreCase) == 0);
			        if (targetType == null) continue;
			        var targetValue = Activator.CreateInstance(targetType, value) as Ifc4.MeasureResource.IfcValue;
                    yield return new IfcPropertySingleValueTransient
                    {
                        Name = name, 
                        NominalValue = targetValue
                    };
			    }
				//##
			} 
		}
		IEnumerable<IIfcExternalReferenceRelationship> IIfcPropertyAbstraction.HasExternalReferences 
		{ 
			get
			{
				return Model.Instances.Where<IIfcExternalReferenceRelationship>(e => e.RelatedResourceObjects != null &&  e.RelatedResourceObjects.Contains(this));
			} 
		}

	//## Custom code
	//##
	}
}