import { useEffect, useState } from "react";
import axios from "axios";

interface PlacesDataChuquisaca {
  id: number;
  espName: string;
  engName: string;
  espDescription: string;
  engDescription: string;
  image: string;
  type: string;
  placeId: number;
}

const usePlacesDataForChuquisaca = () => {
  const [touristicPlacesData, setTouristicPlacesData] = useState<
    PlacesDataChuquisaca[]
  >([]);
  const [foodsData, setFoodsData] = useState<PlacesDataChuquisaca[]>([]);
  const [partiesData, setPartiesData] = useState<PlacesDataChuquisaca[]>([]);
  const [error, setError] = useState<string | null>(null);
  // placeId for Chuquisaca is 3
  const placeId = 3;

  useEffect(() => {
    const fetchPlacesData = async () => {
      try {
        const response = await axios.get(
          "https://localhost:7183/api/PlacesData/byPlaceId?placeId=" + placeId,
        );
        const data = response.data;

        const filteredTouristicPlaces = data.filter(
          (place: PlacesDataChuquisaca) =>
            place.type === "touristic_place" && place.placeId === placeId
        );
        const filteredFoods = data.filter(
          (place: PlacesDataChuquisaca) =>
            place.type === "food" && place.placeId === placeId
        );
        const filteredParties = data.filter(
          (place: PlacesDataChuquisaca) =>
            place.type === "party" && place.placeId === placeId
        );
        // console.log("filteredTouristicPlaces", filteredTouristicPlaces);
        // console.log("filteredFoods", filteredFoods);
        // console.log("filteredParties", filteredParties);
        setTouristicPlacesData(filteredTouristicPlaces);
        setFoodsData(filteredFoods);
        setPartiesData(filteredParties);
      } catch (error) {
        setError("Error occurred while fetching places data");
        console.error("Error occurred while fetching places data:", error);
      }
    };

    fetchPlacesData();
  }, []);

  return { touristicPlacesData, foodsData, partiesData, error };
};

export default usePlacesDataForChuquisaca;
