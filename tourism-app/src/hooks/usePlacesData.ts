import { useEffect, useState } from "react";
import { supabase } from '../supabase/client'

interface PlacesData {
  id: number;
  esp_name: string;
  eng_name: string;
  esp_description: string;
  eng_description: string;
  image: string;
  type: string;
  place_id: number;
}

const usePlacesData = (placeId: number) => {
  const [touristicPlacesData, setTouristicPlacesData] = useState<PlacesData[]>([]);
  const [foodsData, setFoodsData] = useState<PlacesData[]>([]);
  const [partiesData, setPartiesData] = useState<PlacesData[]>([]);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    const fetchPlacesData = async () => {
      try {
        const { data, error } = await supabase
          .from('places_data')
          .select('*')
          .eq('place_id', placeId);

        if (error) throw error;

        const filteredTouristicPlaces = data.filter(
          place => place.type === "touristic_place"
        );
        const filteredFoods = data.filter(
          place => place.type === "food"
        );
        const filteredParties = data.filter(
          place => place.type === "party"
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
  }, [placeId]);

  return { touristicPlacesData, foodsData, partiesData, error };
};

export default usePlacesData;
