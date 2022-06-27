import React, { useState } from 'react';
// nextjs
// next-auth
// @material-ui
import { DialogActions, DialogContent } from '@material-ui/core';
// components
import DialogModal from '@components/ModalDialog/Modal';
import NoButton from '@components/Buttons/No/NoButton';
import YesButton from '@components/Buttons/Yes/YesButton';
import IndustryTypeIcon from '@components/IndustryTypeIcon';
// other components
import { Spinner } from 'react-bootstrap';
// models
import IPortfolio from '@core/models/portfolio.model';
// services
import PortfolioService from '@core/services/web-api/Portfolio';
import { RootStateOrAny, useSelector } from 'react-redux';

type DeletePortfolioFormProps = {
  portfolio: IPortfolio;
  onClose: () => void;
  onDeleteSuccess: (portfolio: IPortfolio) => void;
  isOpen: boolean;
};

const DeletePortfolioForm: React.FC<DeletePortfolioFormProps> = ({
  portfolio,
  onClose,
  onDeleteSuccess,
  isOpen,
}) => {
  const { token } = useSelector((state: RootStateOrAny) => state.app);
  const [submitting, setSubmitting] = useState<boolean>(false);

  const handleDeletePortfolio = async () => {
    if (portfolio && portfolio.portfolioId) {
      try {
        setSubmitting(true);
        const portfolioService = new PortfolioService(token);

        const response = await portfolioService.deletePortfolio(
          portfolio.portfolioId,
        );

        if (response.httpStatusCode == 200) {
          onDeleteSuccess(portfolio);
        } else {
          debugger;
          console.log(`failed deleting `, portfolio);
        }
      } catch (error) {
        debugger;
        console.log({ error });
      }

      setSubmitting(false);
    }
  };

  return (
    <>
      <DialogModal
        isOpen={isOpen}
        handleClose={onClose}
        title={'Remove Portfolio'}
        height='60vh'
        subtitle={''}>
        <DialogContent>
          <div className='flex flex-1'>
            <div className='flex flex-1 justify-center  py-1'>
              <IndustryTypeIcon
                industryGroupId={portfolio.industryGroupId}
                iconSize={128}
              />
            </div>
          </div>
          <div className='flex flex-1 py-1'>
            <label className='flex flex-1 justify-center  text-3xl font-semibold  text-gray-600   py-1'>
              Portfolio
            </label>
          </div>

          <div className='flex flex-1 py-1'>
            <label className='flex flex-1 justify-center  text-2xl font-semibold  text-gray-600   py-1'>
              {portfolio.name}
            </label>
          </div>

          <div className='flex flex-1 py-1'>
            <label className='flex flex-1 justify-center  text-2xl font-semibold  text-gray-600   py-1'>
              Remove portfolio ?
            </label>
          </div>
        </DialogContent>
        <DialogActions>
          <div className='flex flex-1'>
            <div className='flex w-1/2 justify-end pr-4'>
              <YesButton
                onClick={handleDeletePortfolio}
                disabled={submitting}
              />
            </div>
            <div className='flex w-1/2 justify-start pl-4'>
              <NoButton onClick={onClose} disabled={submitting} />
            </div>
          </div>
          {submitting ? <Spinner animation='border' variant='warning' /> : null}
        </DialogActions>
      </DialogModal>
    </>
  );
};

export default DeletePortfolioForm;
