import { useState, useEffect } from 'react';
import axios from 'axios';

interface Place {
  title: string;
  description: string;
  imageSrc: string;
}

const usePlaces = () => {
  const [places, setPlaces] = useState<Place[]>([]);
  const [loading, setLoading] = useState<boolean>(true);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    const fetchPlaces = async () => {
      try {
        const response = await axios.get<Place[]>('https://localhost:7183/api/places');
        setPlaces(response.data);
      } catch (err) {
        setError('Error occurred while fetching places');
      } finally {
        setLoading(false);
      }
    };

    fetchPlaces();
  }, []);

  return { places, loading, error };
};

export default usePlaces;
