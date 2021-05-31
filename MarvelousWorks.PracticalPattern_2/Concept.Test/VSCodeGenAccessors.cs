﻿// ------------------------------------------------------------------------------
//<autogenerated>
//        This code was generated by Microsoft Visual Studio Team System 2005.
//
//        Changes to this file may cause incorrect behavior and will be lost if
//        the code is regenerated.
//</autogenerated>
//------------------------------------------------------------------------------
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarvellousWorks.PracticalPattern.Concept.Test
{
[System.Diagnostics.DebuggerStepThrough()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TestTools.UnitTestGeneration", "1.0.0.0")]
internal class BaseAccessor {
    
    protected Microsoft.VisualStudio.TestTools.UnitTesting.PrivateObject m_privateObject;
    
    protected BaseAccessor(object target, Microsoft.VisualStudio.TestTools.UnitTesting.PrivateType type) {
        m_privateObject = new Microsoft.VisualStudio.TestTools.UnitTesting.PrivateObject(target, type);
    }
    
    protected BaseAccessor(Microsoft.VisualStudio.TestTools.UnitTesting.PrivateType type) : 
            this(null, type) {
    }
    
    internal virtual object Target {
        get {
            return m_privateObject.Target;
        }
    }
    
    public override string ToString() {
        return this.Target.ToString();
    }
    
    public override bool Equals(object obj) {
        if (typeof(BaseAccessor).IsInstanceOfType(obj)) {
            obj = ((BaseAccessor)(obj)).Target;
        }
        return this.Target.Equals(obj);
    }
    
    public override int GetHashCode() {
        return this.Target.GetHashCode();
    }
}


[System.Diagnostics.DebuggerStepThrough()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TestTools.UnitTestGeneration", "1.0.0.0")]
internal class MarvellousWorks_PracticalPattern_Concept_Indexer_SimpleRowCollectionAccessor : BaseAccessor {
    
    protected static Microsoft.VisualStudio.TestTools.UnitTesting.PrivateType m_privateType = new Microsoft.VisualStudio.TestTools.UnitTesting.PrivateType(typeof(global::MarvellousWorks.PracticalPattern.Concept.Indexer.SingleColumnCollection));
    
    internal MarvellousWorks_PracticalPattern_Concept_Indexer_SimpleRowCollectionAccessor(global::MarvellousWorks.PracticalPattern.Concept.Indexer.SingleColumnCollection target) : 
            base(target, m_privateType) {
    }
    
    internal static string[] countries {
        get {
            string[] ret = ((string[])(m_privateType.GetStaticField("countries")));
            return ret;
        }
        set {
            m_privateType.SetStaticField("countries", value);
        }
    }
    
    internal static global::MarvellousWorks.PracticalPattern.Concept.Indexer.SingleColumnCollection CreatePrivate() {
        object[] args = new object[0];
        Microsoft.VisualStudio.TestTools.UnitTesting.PrivateObject priv_obj = new Microsoft.VisualStudio.TestTools.UnitTesting.PrivateObject(typeof(global::MarvellousWorks.PracticalPattern.Concept.Indexer.SingleColumnCollection), new System.Type[0], args);
        return ((global::MarvellousWorks.PracticalPattern.Concept.Indexer.SingleColumnCollection)(priv_obj.Target));
    }
}
[System.Diagnostics.DebuggerStepThrough()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TestTools.UnitTestGeneration", "1.0.0.0")]
internal class MarvellousWorks_PracticalPattern_Concept_Indexer_FederateIndexerAccessor : BaseAccessor {
    
    protected static Microsoft.VisualStudio.TestTools.UnitTesting.PrivateType m_privateType = new Microsoft.VisualStudio.TestTools.UnitTesting.PrivateType(typeof(global::MarvellousWorks.PracticalPattern.Concept.Indexer.FederateIndexer));
    
    internal MarvellousWorks_PracticalPattern_Concept_Indexer_FederateIndexerAccessor(global::MarvellousWorks.PracticalPattern.Concept.Indexer.FederateIndexer target) : 
            base(target, m_privateType) {
    }
    
    internal static global::MarvellousWorks.PracticalPattern.Concept.Indexer.FederateIndexer CreatePrivate() {
        object[] args = new object[0];
        Microsoft.VisualStudio.TestTools.UnitTesting.PrivateObject priv_obj = new Microsoft.VisualStudio.TestTools.UnitTesting.PrivateObject(typeof(global::MarvellousWorks.PracticalPattern.Concept.Indexer.FederateIndexer), new System.Type[0], args);
        return ((global::MarvellousWorks.PracticalPattern.Concept.Indexer.FederateIndexer)(priv_obj.Target));
    }
}
}
