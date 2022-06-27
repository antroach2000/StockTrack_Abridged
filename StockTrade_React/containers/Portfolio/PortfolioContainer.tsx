import React, { useReducer, useState } from 'react';
// nextjs
import { useRouter } from 'next/router';
// next-auth
// components
import AddPortfolio from '@components/Portfolio/AddForm/AddPortfolioForm';
import DeletePortfolioForm from '@components/Portfolio/DeleteForm/DeletePortfolioForm';
import PortfolioNameListItem from '@modules/portfolio/PortfolioNameListItem';
// models
import IPortfolio from '@models/portfolio.model';
// services
import EditPortfolioForm from '@components/Portfolio/EditForm/EditPortfolioForm';
import { AddPlaceHolderListItem } from '@components/ListItems/AddPlaceHolderListItem';

const actionTypes = {
  addNew: 'ADD_NEW',
  remove: 'REMOVE',
  edit: 'EDIT',
};

function portfolioReducer(state: any, action: any) {
  switch (action.type) {
    case actionTypes.addNew:
      return [...state, { ...action.payload, id: action.payload.portfolioId }];

    case actionTypes.remove:
      return [
        ...state.filter(
          (item: IPortfolio) => item.portfolioId !== action.payload.portfolioId,
        ),
      ];
      
    case actionTypes.edit:
      const index = state.findIndex(
        (item: IPortfolio) => item.portfolioId === action.payload.portfolioId,
      );

      const newState = [...state];
      const portfolio = newState[index];

      portfolio.name = action.payload.name;
      portfolio.stockExchangeId = action.payload.stockExchangeId;
      portfolio.industryDescription = action.payload.industryDescription;
      portfolio.industryGroupId = action.payload.industryGroupId;

      return [...newState];

    default:
      throw new Error(`Unhandled type: ${action.type}`);
  }
}

type PortfolioContainerProps = {
  portfolioData: IPortfolio[];
};

const PortfolioContainer: React.FC<PortfolioContainerProps> = ({
  portfolioData,
}) => {
  const router = useRouter();
  const [portfolio, dispatch] = useReducer(portfolioReducer, portfolioData);
  const [openAddPortfolioForm, setAddOpenPortfolioForm] =
    useState<boolean>(false);
  const [openDeletePortfolioForm, setOpenDeletePortfolioForm] =
    useState<boolean>(false);
  const [openEditPortfolioForm, setEditOpenPortfolioForm] =
    useState<boolean>(false);
  const [selectedPortfolio, setSelectedPortfolio] = useState<IPortfolio>();

  const handleViewPortfolio = (selected: IPortfolio) => {
    router.push({
      pathname: `/portfolio/${selected.portfolioId}`,
      query: { portfolioName: selected.name },
    });
  };

  return (
    <>
      <div className='max-h-min'>
        <div className='flex flex-wrap'>
          <AddPlaceHolderListItem
            text='ADD NEW PORTFOLIO'
            onAdd={() => setAddOpenPortfolioForm(true)}
          />

          {portfolio && portfolio.length > 0 ? (
            portfolio.map((item: IPortfolio) => {
              return (
                <PortfolioNameListItem
                  key={item.portfolioId}
                  portfolioItem={item}
                  onViewPortfolio={() => handleViewPortfolio(item)}
                  onOpenDeletePortfolioForm={(portfolio) => {
                    setSelectedPortfolio(portfolio);
                    setOpenDeletePortfolioForm(true);
                  }}
                  onEditPortfolio={(item) => {
                    setSelectedPortfolio(item);
                    setEditOpenPortfolioForm(true);
                  }}
                />
              );
            })
          ) : (
            <span className='flex flex-row px-10 py-10 text-red-500 text-2xl font-semibold'>
              You have no portfolios setup, click the 'Plus' icon to add a
              portfolio
            </span>
          )}
        </div>

        {openDeletePortfolioForm && selectedPortfolio ? (
          <DeletePortfolioForm
            isOpen={openDeletePortfolioForm}
            portfolio={selectedPortfolio}
            onClose={() => setOpenDeletePortfolioForm(false)}
            onDeleteSuccess={() => {
              dispatch({
                type: actionTypes.remove,
                payload: selectedPortfolio,
              });
              setOpenDeletePortfolioForm(false);
            }}
          />
        ) : null}

        {openEditPortfolioForm && selectedPortfolio ? (
          <EditPortfolioForm
            isOpen={openEditPortfolioForm}
            portfolio={selectedPortfolio}
            onClose={() => setEditOpenPortfolioForm(false)}
            onSaveSuccess={(portfolio) => {
              dispatch({ type: actionTypes.edit, payload: portfolio });
              setEditOpenPortfolioForm(false);
            }}
          />
        ) : null}

        {openAddPortfolioForm ? (
          <div>
            <AddPortfolio
              onClose={() => setAddOpenPortfolioForm(false)}
              onSaveSuccess={(newPortfolio) => {
                dispatch({ type: actionTypes.addNew, payload: newPortfolio });
                setAddOpenPortfolioForm(false);
              }}
              isOpen={openAddPortfolioForm}
            />
          </div>
        ) : null}
      </div>
    </>
  );
};

export default PortfolioContainer;
