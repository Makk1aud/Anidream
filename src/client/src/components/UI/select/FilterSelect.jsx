import Select from 'react-select'

export default function FilterSelect({options, isMulti}) {

  return (
    <Select options={options} isMulti={isMulti}/>
  )
}
