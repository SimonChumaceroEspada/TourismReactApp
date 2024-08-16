import React, { useEffect, useState } from 'react';
import axios from 'axios';

// Define una interfaz para el lugar turístico
interface Place {
  Id: number;
  EspName: string;
  EspDescription: string;
  EngDescription: string;
  Image: string;
  PlaceId: number;
  EngName: string;
}

const PlacesList: React.FC = () => {
  const [places, setPlaces] = useState<Place[]>([]);
  const [loading, setLoading] = useState<boolean>(true);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    const fetchPlaces = async () => {
      try {
        const response = await axios.get('https://localhost:7183/api/places');
        setPlaces(response.data.slice(0, 3));
        setLoading(false);
      } catch (err) {
        setError('Error occurred while fetching places');
        setLoading(false);
      }
    };

    fetchPlaces();
  }, []);

  if (loading) return <p>Loading...</p>;
  if (error) return <p>{error}</p>;

  return (
    <div className="places-list">
      {places.map((place) => (
        <div className="place-card" key={place.Id}>
          <img src={place.Image} alt={place.EngName} className="place-image" />
          <h2>{place.EngName}</h2>
          <p>{place.EngDescription}</p>
        </div>
      ))}
    </div>
  );
};

export default PlacesList;
