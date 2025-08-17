import { useRef } from "react"

export const useScroll = () => {
    const ref = useRef(null);

    const scrollTo = (options) => {
        ref.current?.scrollIntoView({
            behaivor: 'smooth',
            block: 'end'
        });
    };

    return [ref, scrollTo];
}