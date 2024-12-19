import { useEffect, useState } from "react";
import { supabase } from '../supabase/client';

interface TouristicPlace {
  id: number;
  name: string;
  capital: string;
  image: string;
  esp_description: string;
  eng_description: string;
}

const useTouristicPlacesById = () => {
  const [touristicPlaces, setTouristicPlaces] = useState<TouristicPlace[]>([]);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    const fetchPlaces = async () => {
      try {
        const getRandomIds = () => {
          const ids = new Set<number>();
          while (ids.size < 3) {
            ids.add(Math.floor(Math.random() * 9) + 2); // Números del 2 al 10
          }
          return Array.from(ids);
        };

        const randomIds = getRandomIds();

        const { data, error } = await supabase
          .from('places')
          .select('*')
          .in('id', randomIds);

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