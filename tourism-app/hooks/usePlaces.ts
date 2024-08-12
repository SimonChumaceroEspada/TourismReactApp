import { useEffect, useState } from "react";
import axios from "axios";

interface Place {
  id: number;
  name: string;
  description: string;
  capital: string;
  image: string;
}

const usePlaces = () => {
  const [places, setPlaces] = useState<Place[]>([]);

  useEffect(() => {
    axios
      .get("https://localhost:7183/api/places")
      .then((response) => {
        console.log(response.data); 
        if (Array.isArray(response.data)) {
          setPlaces(response.data);
        } else {
          console.error("Response is not an array:", response.data);
        }
      })
      .catch((error) => {
        console.error("Error occurred while fetching places:", error);
      });
  }, []);

  return places;
};

export default usePlaces;

