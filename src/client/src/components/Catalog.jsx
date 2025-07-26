import React from 'react'
import SectionTitle from './UI/title/SectionTitle'
import AnimeCard from './AnimeCard'


export default function Catalog() {
  return (
    <div>
    	<SectionTitle title='Каталог'/>
			<AnimeCard imagePath='/anime-previews/magic-fight.webp' />
    </div>
  )
}
