import { useRef } from "react"

export const useScroll = () => {
    const ref = useRef(null);

    const scrollTo = (options) => {
        console.log('Scrolling to:', ref.current);
        ref.current?.scrollIntoView({
            behavior: 'smooth',
            block: 'end'
        });
    };

    return [ref, scrollTo];
}