import React from "react";
import usePlaces from "../hooks/usePlaces";

const PlacesList = () => {
  const places = usePlaces();

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