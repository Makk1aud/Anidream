import axios from "axios";
import { resolvePath } from "react-router-dom";

const API_BASE_URL = "http://localhost:5001/api";

export const fetchMediaList = async (title = "") => {
  const params = new URLSearchParams();

  if (title && title.trim()) {
    params.append("title", title.trim())
  }

  const queryString = params.toString();
  const url = queryString 
    ? `${API_BASE_URL}/media?${queryString}`
    : `${API_BASE_URL}/media`;
    
  const response = await axios.get(url);
  return response.data;
};

export const fetchMediaById = async (mediaId) => {
  const response = await axios.get(`${API_BASE_URL}/media/${mediaId}`)

  return response.data;
};

export const fetchMediaImage = (alias) => {
  return `${API_BASE_URL}/Storage/media/image/${alias}`;
}

export const fetchSeriesByNum = (alias, num) => {
  return `${API_BASE_URL}/Storage/media/video/${alias}/episode/${num}`
}
