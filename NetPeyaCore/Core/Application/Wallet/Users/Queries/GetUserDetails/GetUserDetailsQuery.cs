using Core.Application.Wallet.Users.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Application.Wallet.Users.Queries.GetUserDetails
{
    public class GetUserDetailsQuery : IRequest<UserDetailsModel>
    {
        int _userID;

        public int UserID
        {
            get { return _userID; }
            set { _userID = Int32.Parse(value.ToString()); }
        }
    }
}
