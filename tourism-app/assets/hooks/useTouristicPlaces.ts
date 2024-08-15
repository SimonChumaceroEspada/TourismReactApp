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

const useTouristicPlaces = () => {
  const [touristicPlaces, setTouristicPlaces] = useState<TouristicPlace[]>([]);

  useEffect(() => {
    axios
      .get("https://localhost:7183/api/TouristicPlace")
      .then((response) => {
        console.log(response.data);
        if (Array.isArray(response.data)) {
          const sortedData = response.data.sort((a, b) => a.id - b.id);
          setTouristicPlaces(sortedData);
        } else {
          console.error("Response is not an array:", response.data);
        }
      })
      .catch((error) => {
        console.error("Error occurred while fetching places:", error);
      });
  }, []);

  return touristicPlaces;
};

export default useTouristicPlaces;
