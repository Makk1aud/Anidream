import React, { use } from 'react'
import { useParams } from 'react-router-dom'

export default function AnimeIdPage() {
  const params = useParams()

  return (
    <div>
        <h1>Вы на странице аниме с ID {params.id}</h1>
    </div>
  )
}
