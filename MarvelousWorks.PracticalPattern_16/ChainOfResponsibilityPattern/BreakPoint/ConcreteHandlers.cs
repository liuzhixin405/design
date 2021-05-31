using System;
using System.Collections.Generic;
using System.Diagnostics;
namespace MarvellousWorks.PracticalPattern.ChainOfResponsibilityPattern.BreakPoint
{
    /// <summary>
    /// 具体操作类型
    /// </summary>
    public class InternalHandler : HandlerBase
    {
        public InternalHandler() : base(PurchaseType.Internal) { }
        public override void Process(Request request) { request.Price *= 0.6; }
    }

    public class MailHandler : HandlerBase
    {
        public MailHandler() : base(PurchaseType.Mail) { }
        public override void Process(Request request) { request.Price *= 1.3; }
    }

    public class DiscountHandler : HandlerBase
    {
        public DiscountHandler() : base(PurchaseType.Discount) { }
        public override void Process(Request request) { request.Price *= 0.9; }
    }

    public class RegularHandler : HandlerBase
    {
        public RegularHandler() : base(PurchaseType.Regular) { }
        public override void Process(Request request) { }
    }
}
