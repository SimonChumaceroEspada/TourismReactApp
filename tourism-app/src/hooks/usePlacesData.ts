import { useEffect, useState } from "react";
import axios from "axios";

interface PlacesData {
  id: number;
  espName: string;
  engName: string;
  espDescription: string;
  engDescription: string;
  image: string;
  type: string;
  placeId: number;
}

const usePlacesData = (placeId: number) => {

  const [touristicPlacesData, setTouristicPlacesData] = useState<PlacesData[]>([]);
  const [foodsData, setFoodsData] = useState<PlacesData[]>([]);
  const [partiesData, setPartiesData] = useState<PlacesData[]>([]);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    const fetchPlacesData = async () => {
      try {
        const response = await axios.get(
          "https://localhost:7183/api/PlacesData/byPlaceId?placeId=" + placeId
        );
        const data = response.data;

        const filteredTouristicPlaces = data.filter(
          (place: PlacesData) =>
            place.type === "touristic_place" && place.placeId === placeId
        );
        const filteredFoods = data.filter(
          (place: PlacesData) =>
            place.type === "food" && place.placeId === placeId
        );
        const filteredParties = data.filter(
          (place: PlacesData) =>
            place.type === "party" && place.placeId === placeId
        );
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

export default usePlacesData;
