using System;
using System.Collections.Generic;
using Common;
namespace Server
{
    /// <summary>
    /// 用来模拟的联系人信息库
    /// </summary>
    internal class ContactStore : Dictionary<int, Contact>
    {
        public ContactStore()
        {
            Add(7, new Contact(7, "manager", 25));
            Add(1, new Contact(1, "president", 34));
            Add(23, new Contact(23, "sales", 22));
        }
    }

    /// <summary>
    /// 有DTO的服务端对象设计
    /// </summary>
    public class ContractService : IContact
    {
        private ContactStore store = new ContactStore();

        #region IContact Members
        public Contact CreateDTO(int id)
        {
            return store[id];
        }

        public void SaveDTO(Contact dto)
        {
            if (dto == null) throw new ArgumentNullException("dto");
            store[dto.Id] = dto;
        }
        #endregion
    }

}
