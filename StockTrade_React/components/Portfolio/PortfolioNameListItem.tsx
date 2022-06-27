import React from 'react';
// models
import IPortfolio from '@core/models/portfolio.model';
// components
import { COUNTUP_TOTAL_VALUE } from '@core/constants/Constants';
import CountUp from 'react-countup';
import LoadImage from '@components/LoadImage/LoadImage';
import IndustryTypeIcon from '@components/IndustryTypeIcon';
import EditButton from '@components/Buttons/Edit/EditButton';
import DeleteButton from '@components/Buttons/Delete/DeleteButton';
import ViewButton from '@components/Buttons/View/ViewButton';

type PortfolioNameListItemProps = {
  portfolioItem: IPortfolio;
  onViewPortfolio: (item: IPortfolio) => void;
  onOpenDeletePortfolioForm: (item: IPortfolio) => void;
  onEditPortfolio: (item: IPortfolio) => void;
};

const PortfolioNameListItem: React.FC<PortfolioNameListItemProps> = ({
  portfolioItem,
  onViewPortfolio,
  onOpenDeletePortfolioForm,
  onEditPortfolio,
}) => {
  return (
    <>
      <div className='flex flex-col w-96 bg-white justify-center rounded shadow-lg p-8 m-4'>
        <span className='flex items-end justify-end p-4'>
          <EditButton
            onClick={() => onEditPortfolio(portfolioItem)}
            disabled={false}
            text='EDIT'
          />
        </span>

        <div className='grid gap-x-8 gap-y-4 grid-cols-3'>
          <div className='text-gray-500'>
            <IndustryTypeIcon
              industryGroupId={portfolioItem.industryGroupId}
              iconSize={128}
            />
          </div>

          {portfolioItem.countryFlagPath ? (
            <LoadImage
              imageUrl={portfolioItem.countryFlagPath}
              width={32}
              height={32}
            />
          ) : null}
        </div>

        <div className='text-base py-8'>
          <span className='flex text-xl items-center justify-center text-gray-700 py-2'>
            {portfolioItem.industryDescription}
          </span>
          <span className='flex text-xl items-center justify-center text-gray-700 py-2'>
            Portfolio
          </span>
          <span className='flex font-semibold text-xl items-center justify-center text-gray-600 py-2'>
            {portfolioItem.name}
          </span>
          <span className='flex text-base items-center justify-center text-gray-700 py-2'>
            Paid value
          </span>
          <span className='flex font-semibold text-base items-center justify-center text-gray-600 py-2'>
            <CountUp
              end={portfolioItem.paid ?? 0}
              decimals={2}
              prefix={portfolioItem.countryCurrencySymbol}
              duration={COUNTUP_TOTAL_VALUE}
              separator=','
            />
          </span>
          <span className='flex semibold text-base items-center justify-center text-gray-700 py-2'>
            Companies in portfolio
          </span>
          <span className='flex items-center justify-center'>
            {portfolioItem.companyCount == 0 ? (
              <>
                <span className='flex font-bold text-base items-center justify-center text-gray-600 py-2'>
                  No companies in portfolio
                </span>
                <div className='py-10'></div>
              </>
            ) : (
              <>
                <div className='text-base py-2'>
                  <span className='flex font-bold text-base items-center justify-center text-gray-600 py-2'>
                    <CountUp
                      end={portfolioItem.companyCount ?? 0}
                      decimals={0}
                      duration={COUNTUP_TOTAL_VALUE}
                      separator=','
                    />
                  </span>
                </div>
              </>
            )}
          </span>

          <div className='flex flex-1'>
            <div className='flex w-1/2 items-start pl-4'>
              <DeleteButton
                onClick={() => onOpenDeletePortfolioForm(portfolioItem)}
                disabled={
                  portfolioItem.companyCount
                    ? portfolioItem.companyCount > 0
                    : false
                }
                text='DELETE'
              />
            </div>
            <div className='flex w-1/2 justify-end  pr-2'>
              <ViewButton
                onClick={() => onViewPortfolio(portfolioItem)}
                disabled={portfolioItem.companyCount === 0}
                text='VIEW'
              />
            </div>
          </div>
        </div>
      </div>
    </>
  );
};

export default PortfolioNameListItem;
