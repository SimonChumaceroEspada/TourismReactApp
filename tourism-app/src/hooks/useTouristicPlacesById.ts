import { useEffect, useState } from "react";
import { supabase } from '../supabase/client';

interface TouristicPlace {
  id: number;
  esp_name: string;
  eng_name: string;
  esp_description: string;
  eng_description: string;
  image: string;
  place_id: number;
}

const useTouristicPlacesById = () => {
  const [touristicPlaces, setTouristicPlaces] = useState<TouristicPlace[]>([]);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    const fetchPlaces = async () => {
      try {
        const { data, error } = await supabase
          .from('places')
          .select('*')
          .in('id', [7, 8, 9]);

        if (error) throw error;
        setTouristicPlaces(data);
      } catch (error) {
        console.error("Error occurred while fetching places:", error);
        setError("Error occurred while fetching places");
      }
    };

    fetchPlaces();
  }, []);

  return { touristicPlaces, error };
};

export default useTouristicPlacesById;