import Select from "react-select";
import cl from "./FilterSelect.module.css";

export default function FilterSelect({ options, placeholder, isMulti }) {
  return (
      <Select
        className={cl.select}
        classNamePrefix="filter-select"
        options={options}
        isMulti={isMulti}
        placeholder={placeholder}
      />
  );
}
