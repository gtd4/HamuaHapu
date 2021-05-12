using HamuaRegistrationApi.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HamuaRegistrationApi.DAL.Services.Communication
{
    public class TangataResponse : BaseResponse
    {
        public Tangata Tangata { get; private set; }

        private TangataResponse(bool success, string message, Tangata tangata) : base(success, message)
        {
            Tangata = tangata;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="category">Saved category.</param>
        /// <returns>Response.</returns>
        public TangataResponse(Tangata tangata) : this(true, string.Empty, tangata)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public TangataResponse(string message) : this(false, message, null)
        { }
    }
}