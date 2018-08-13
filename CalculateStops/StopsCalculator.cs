using CalculateStops.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CalculateStops
{
    public class StopsCalculator 
    {
        public GridResultDTO CalculateStops(string input)
        {            
            return Search(input);
        }        
        public int getDays(int number, string strtime)
        {
            var msg = Utils.GetListEnum(typeof(DaysInYear)).Where(w => w.Name == strtime).FirstOrDefault();
            return Convert.ToInt32(msg.StringDescription);
        }        
        public List<ResultDTO> AddResultDTO(string MGLTView, List<ResultDTO> listResultDTO, GridDTO starshipsDTO)
        {
            foreach (var item in starshipsDTO.Results)
            {
                ResultDTO resultDTO = new ResultDTO();
                string name = item.Name;
                string consumables = item.Consumables;
                int MGLT = 0;
                int stops = 0;
                if (item.MGLT != "unknown")
                    MGLT = Convert.ToInt32(item.MGLT);

                string[] consumablesSplit = consumables.Split(' ');
                if (consumablesSplit.Length == 2 && MGLT != 0)
                {
                    int consumableNumber = Convert.ToInt32(consumablesSplit[0]); // get the consumables lemits for the the star ship
                    string strTime = consumablesSplit[1];  // Get the Start time form consumable 
                    int consumablesDays = getDays(consumableNumber, strTime);

                    // Calculate Stops 
                    //MGLTView /*(distance)*/ / 4 days
                    stops = Convert.ToInt32(Convert.ToInt32(MGLTView) / (consumableNumber * consumablesDays * 24 * MGLT));
                }

                resultDTO.Name = item.Name;
                resultDTO.Value = stops;
                listResultDTO.Add(resultDTO);
            }

            return listResultDTO;
        }        
        public GridResultDTO Search(string MGLTView)
        {
            string url = "http://swapi.co/api/starships/?page=1"; // Need to move to config
            Rest rest = new Rest();
            GridDTO starshipsDTO = rest.SendRequestion(url);

            GridResultDTO gridResultDTO = new GridResultDTO();
            if (starshipsDTO == null)
                return gridResultDTO;

            List<ResultDTO> listResultDTO = new List<ResultDTO>();
            AddResultDTO(MGLTView, listResultDTO, starshipsDTO);
            
            for (int i = 0; i < Convert.ToInt32(starshipsDTO.Count) / 10; i++)
            {
                if (!string.IsNullOrEmpty(starshipsDTO.Next))
                {
                    starshipsDTO = rest.SendRequestion(starshipsDTO.Next);
                    if (starshipsDTO != null)
                        AddResultDTO(MGLTView, listResultDTO, starshipsDTO);
                }
            }

            gridResultDTO.MGLTView = MGLTView;
            gridResultDTO.Count = starshipsDTO.Count;
            gridResultDTO.Next = starshipsDTO.Next;
            gridResultDTO.Previous = starshipsDTO.Previous;
            gridResultDTO.ResultDTO = listResultDTO;

            return gridResultDTO;
        }
    }
}
