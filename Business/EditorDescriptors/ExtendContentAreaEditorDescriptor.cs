using EPiServer.Cms.Shell.UI.ObjectEditing.EditorDescriptors;
using EPiServer.Core;
using EPiServer.Shell.ObjectEditing;
using EPiServer.Shell.ObjectEditing.EditorDescriptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EPiServerResearch.Business.EditorDescriptors
{
    [EditorDescriptorRegistration(TargetType = typeof(ContentArea), EditorDescriptorBehavior = EditorDescriptorBehavior.OverrideDefault)]
    public class ExtendContentAreaEditorDescriptor : ContentAreaEditorDescriptor
    {
        public override void ModifyMetadata(ExtendedMetadata metadata, IEnumerable<Attribute> attributes)
        {
            base.ModifyMetadata(metadata, attributes);

            metadata.OverlayConfiguration["customType"] = "alloy/overlay/StrategyContentArea";
        }
    }
}