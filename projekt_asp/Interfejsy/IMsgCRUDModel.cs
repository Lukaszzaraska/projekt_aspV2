using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projekt_asp.Models
{
    public interface IMsgCRUDModel
    {
        void SendMsg(MsgModel Msg, RegisterModel login);
        IList<MsgModel> FindAllUser();
        MsgModel FindMsgById(int id);

        IList<MsgModel> FindMsg(string login);

        int NewMsg(string login);

        MsgModel Readed(int id);

        MsgModel Delete(int id);
    }
}
