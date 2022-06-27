import React from 'react';
// other components
import { Analyst_Rating } from '@core/constants/AnalystRating';

type AnalystRatingProps = {
  rating: string;
};
const AnalystRating: React.FC<AnalystRatingProps> = ({ rating }) => {
  const renderRating = () => {
    switch (rating) {
      case Analyst_Rating.ANALYST_RATING_SELL:
        return (
          <span className='bg-red-100 text-red-800 text-sm font-medium mr-2 px-2.5 py-0.5 rounded dark:bg-red-200 dark:text-red-900'>
            {rating}
          </span>
        );

      case Analyst_Rating.ANALYST_RATING_NO_RATING:
        return (
          <span className='bg-purple-100 text-purple-800 text-sm font-medium mr-2 px-2.5 py-0.5 rounded dark:bg-purple-200 dark:text-purple-900'>
            {rating}
          </span>
        );

      case Analyst_Rating.ANALYST_RATING_HOLD:
        return (
          <span className='bg-yellow-100 text-yellow-800 text-sm font-medium mr-2 px-2.5 py-0.5 rounded dark:bg-yellow-200 dark:text-yellow-900'>
            {rating}
          </span>
        );

      case Analyst_Rating.ANALYST_RATING_STRONG_BUY:
        return (
          <span className='bg-green-400 text-green-800 text-sm font-medium mr-2 px-2.5 py-0.5 rounded dark:bg-green-200 dark:text-green-900'>
            {rating}
          </span>
        );

      case Analyst_Rating.ANALYST_RATING_BUY:
        return (
          <span className='bg-green-100 text-green-800 text-sm font-medium mr-2 px-2.5 py-0.5 rounded dark:bg-green-200 dark:text-green-900'>
            {rating}
          </span>
        );

      default:
        return <span>{rating}</span>;
    }
  };

  return renderRating();
};

export default AnalystRating;
