import React from 'react'
import { useState } from 'react'
import Select from 'react-select'
import cl from './EpisodeSelector.module.css'

export default function EpisodeSelector({media, onChange, currentEpisode}) {
  if (media.totalEpisodes <= 1) {
    return null;
  }

  const options = Array.from({length: media.totalEpisodes }, (_, i) => ({
    value: i + 1,
    label: `Серия ${i + 1}`
  }));

  return (
    <div className={cl.container}>
      <p className={cl.choice__text}>Выберите серию: </p>
      <Select
        className={cl.select}
        classNamePrefix="episode-select"
        inputId="episode-select"
        options={options}
        value={options.find((opt) => opt.value === currentEpisode)}
        onChange={(selected) => onChange(selected.value)}
        menuPlacement="auto" // auto | top | bottom
        menuPosition="fixed"
      />
    </div>
  );
}
