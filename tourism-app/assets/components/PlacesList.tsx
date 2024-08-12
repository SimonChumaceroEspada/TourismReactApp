import React, { useEffect, useState } from "react";
import axios from "axios";

const PlacesList = () => {
  interface Place {
    id: number;
    name: string;
    description: string;
    capital: string;
    image: string;
  }

  const [places, setPlaces] = useState<Place[]>([]);

    useEffect(() => {
      axios
        .get("https://localhost:7183/api/places")

        .then((response) => {
          console.log(response.data); // Verifica los datos aquí
          if (Array.isArray(response.data)) {
            setPlaces(response.data);
          } else {
            console.error("La respuesta no es un array:", response.data);
          }
        })
        .catch((error) => {
          console.error("Hubo un error recuperando los datos!", error);
        });
    }, []);


  return (
    <div>
      <h1>Lista de Lugares</h1>
      <ul>
        {places.map((place) => (
          <li key={place.id}>
            <h2>{place.name}</h2>
            <p>{place.description}</p>
            <p>
              <strong>Capital:</strong> {place.capital}
            </p>
            <img src={place.image} alt={place.name} width="200" />
          </li>
        ))}
      </ul>
    </div>
  );
};

export default PlacesList;
