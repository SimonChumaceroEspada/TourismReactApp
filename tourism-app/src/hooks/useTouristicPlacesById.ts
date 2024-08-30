import { useEffect, useState } from "react";
import axios from "axios";

interface TouristicPlace {
  id: number;
  espName: string;
  engName: string;
  espDescription: string;
  engDescription: string;
  image: string;
  placeId: number;
}

const useTouristicPlacesById = () => {
  const [touristicPlaces, setTouristicPlaces] = useState<TouristicPlace[]>([]);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    const fetchPlaces = async () => {
      try {
        const response = await axios.get(
          "https://localhost:7183/api/PlacesData/",
        );
        const filteredPlaces = response.data.filter((place: TouristicPlace) =>
          [7, 8, 9].includes(place.id)
        );
        console.log("filteredPlaces", filteredPlaces);
        setTouristicPlaces(filteredPlaces);
      } catch (error) {
        setError("Error occurred while fetching places");
        console.error("Error occurred while fetching places:", error);
      }
    };

    fetchPlaces();
  }, []);

  return touristicPlaces;
};

export default useTouristicPlacesById;