using HamuaRegistrationApi.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HamuaRegistrationApi.DAL.Services.Communication
{
    public class MaraeResponse : BaseResponse
    {
        public Marae Marae { get; private set; }

        private MaraeResponse(bool success, string message, Marae marae) : base(success, message)
        {
            Marae = marae;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="category">Saved category.</param>
        /// <returns>Response.</returns>
        public MaraeResponse(Marae marae) : this(true, string.Empty, marae)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public MaraeResponse(string message) : this(false, message, null)
        { }
    }
}