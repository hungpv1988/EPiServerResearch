using EPiServer.Shell.ObjectEditing;
using EPiServer.Shell.ObjectEditing.EditorDescriptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EPiServerResearch.Business.EditorDescriptors
{
    //[EditorDescriptorRegistration(TargetType =typeof(Strategy), UIHint = StrategyConstants.UIHint)]
    //public class StrategySelector: EditorDescriptor
    //{
    //    public override void ModifyMetadata(ExtendedMetadata metadata, IEnumerable<Attribute> attributes)
    //    {
    //        SelectionFactoryType = typeof(StrategySelectionFactory);
    //        ClientEditingClass = "epi-cms/contentediting/editors/SelectionEditor";
    //        base.ModifyMetadata(metadata, attributes);
    //    }
    //}

    public static class StrategyConstants
    {
        public const string UIHint = "Strategy";
    }
}