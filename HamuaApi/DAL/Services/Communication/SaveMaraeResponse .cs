using HamuaRegistrationApi.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HamuaRegistrationApi.DAL.Services.Communication
{
    public class SaveMaraeResponse : BaseResponse
    {
        public Marae Marae { get; private set; }

        private SaveMaraeResponse(bool success, string message, Marae marae) : base(success, message)
        {
            Marae = marae;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="category">Saved category.</param>
        /// <returns>Response.</returns>
        public SaveMaraeResponse(Marae marae) : this(true, string.Empty, marae)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public SaveMaraeResponse(string message) : this(false, message, null)
        { }
    }
}