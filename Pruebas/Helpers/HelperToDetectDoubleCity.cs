using Pruebas.Models;
using Pruebas.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Pruebas.Helpers
{
    internal class HelperToDetectDoubleCity
    {
        private ServiceGetAllCityInLocalData _serviceGetAllCityInLocalData { get; set; }
        public HelperToDetectDoubleCity(ServiceGetAllCityInLocalData _serviceGetAllCityInLocalData) => this._serviceGetAllCityInLocalData = _serviceGetAllCityInLocalData;

        public void detectAndDeleteDuplicatedCity(List<Root> cityNew)
        {
            try
            {
                if(_serviceGetAllCityInLocalData._allCity.Count > 0)
                {
                    for (var i = 0; i < _serviceGetAllCityInLocalData._allCity.Count; i++)
                    {
                        if (cityNew[0].name == _serviceGetAllCityInLocalData._allCity[i][0].name)
                        {
                            _serviceGetAllCityInLocalData._allCity.RemoveAt(i);
                            i = 0;
                        }
                    }
                    
                }
            }
            catch (Exception ex)
            {
                HelperForWriteErrorMessage.WriteCompleteError("detectAndDeleteDpulicatedCity", ex.Message, "HelperToDetectDoubleCity", ex.HResult);
            }
        }
    }
}
