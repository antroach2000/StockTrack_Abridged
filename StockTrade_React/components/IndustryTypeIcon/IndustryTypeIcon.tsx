import React from 'react';
import { Industry_Type } from '@core/constants/IndustryType';
import { FaBitcoin, FaQuestionCircle } from 'react-icons/fa';
import {
  FcAbout,
  FcAutomotive,
  FcBarChart,
  FcBusinesswoman,
  FcCalculator,
  FcChargeBattery,
  FcDonate,
  FcElectroDevices,
  FcExpired,
  FcFactory,
  FcFlashAuto,
  FcHighBattery,
  FcHome,
  FcIcons8Cup,
  FcIpad,
  FcMoneyTransfer,
  FcMultipleInputs,
  FcOrganization,
  FcPaid,
  FcPodiumWithoutSpeaker,
  FcPrint,
  FcProcess,
  FcRegisteredTrademark,
  FcServices,
  FcShipped,
  FcShop,
  FcSportsMode,
  FcTimeline,
  FcTreeStructure,
  FcUpRight,
} from 'react-icons/fc';

type IndustryTypeIconProps = {
  industryGroupId: Industry_Type | undefined;
  iconSize: number;
};
const IndustryTypeIcon: React.FC<IndustryTypeIconProps> = ({
  industryGroupId,
  iconSize,
}) => {
  const renderIcon = () => {
    if (!industryGroupId) {
      return <FaQuestionCircle size={iconSize} />;
    }
    switch (industryGroupId) {
      case Industry_Type.AUTOMOBILES_COMPONENTS:
        return <FcAutomotive size={iconSize} />;
      case Industry_Type.BANKS:
        return <FcHome size={iconSize} />;
      case Industry_Type.CAPITAL_GOODS:
        return <FcFactory size={iconSize} />;
      case Industry_Type.COMMERCIAL_PROFESSIONAL_SERVICES:
        return <FcDonate size={iconSize} />;
      case Industry_Type.CONSUMER_DISCRETIONARY:
        return <FcPodiumWithoutSpeaker size={iconSize} />;
      case Industry_Type.CONSUMER_DURABLES_APPAREL:
        return <FcShipped size={iconSize} />;
      case Industry_Type.CONSUMER_SERVICES:
        return <FcShop size={iconSize} />;
      case Industry_Type.CONSUMER_STAPLES:
        return <FcProcess size={iconSize} />;
      case Industry_Type.CRYPTO:
        return <FaBitcoin size={iconSize} />;
      case Industry_Type.DIVERSIFIED_FINANCIALS:
        return <FcElectroDevices size={iconSize} />;
      case Industry_Type.ENERGY:
        return <FcChargeBattery size={iconSize} />;
      case Industry_Type.FINANCIALS:
        return <FcBarChart size={iconSize} />;
      case Industry_Type.FOOD_BEVERAGE_TOBACCO:
        return <FcMultipleInputs size={iconSize} />;
      case Industry_Type.FOOD_STAPLES_RETAILING:
        return <FcPaid size={iconSize} />;
      case Industry_Type.HEALTH_CARE:
        return <FcOrganization size={iconSize} />;
      case Industry_Type.HEALTH_CARE_EQUIPMENT_SERVICES:
        return <FcMoneyTransfer size={iconSize} />;
      case Industry_Type.HOUSEHOLD_PERSONAL_PRODUCTS:
        return <FcPrint size={iconSize} />;
      case Industry_Type.INDUSTRIALS:
        return <FcFlashAuto size={iconSize} />;
      case Industry_Type.INFORMATION_TECHNOLOGY:
        return <FcCalculator size={iconSize} />;
      case Industry_Type.INSURANCE:
        return <FcBusinesswoman size={iconSize} />;
      case Industry_Type.MATERIALS:
        return <FcIcons8Cup size={iconSize} />;
      case Industry_Type.MEDIA_ENTERTAINMENT:
        return <FcIpad size={iconSize} />;
      case Industry_Type.PHARMACEUTICALS_BIOTECHNOLOGY_LIFE_SCIENCES:
        return <FcHighBattery size={iconSize} />;
      case Industry_Type.REAL_ESTATE:
        return <FcOrganization size={iconSize} />;
      case Industry_Type.RETAILING:
        return <FcRegisteredTrademark size={iconSize} />;
      case Industry_Type.SEMICONDUCTORS_SEMICONDUCTOR_EQUIPMENT:
        return <FcTimeline size={iconSize} />;
      case Industry_Type.SOFTWARE_SERVICES:
        return <FcSportsMode size={iconSize} />;
      case Industry_Type.TECHNOLOGY_HARDWARE_EQUIPMENT:
        return <FcUpRight size={iconSize} />;
      case Industry_Type.TELECOMMUNICATION_SERVICES:
        return <FcTreeStructure size={iconSize} />;
      case Industry_Type.TRANSPORTATION:
        return <FcExpired size={iconSize} />;
      case Industry_Type.UNKNOWN:
        return <FcAbout size={iconSize} />;
      case Industry_Type.UTILITIES:
        return <FcServices size={iconSize} />;
    }
  };

  return <>{renderIcon()}</>;
};

export default IndustryTypeIcon;
