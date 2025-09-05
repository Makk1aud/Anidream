import React from 'react'
import Slider from 'rc-slider'
import cl from './FilterSlider.module.css'

export default function FilterSlider() {
  return (
    <Slider className={cl.slider}/>
  )
}
